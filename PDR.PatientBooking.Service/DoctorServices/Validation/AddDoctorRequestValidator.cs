using PDR.PatientBooking.Data;
using PDR.PatientBooking.Service.DoctorServices.Requests;
using PDR.PatientBooking.Service.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PDR.PatientBooking.Service.DoctorServices.Validation
{
    public class AddDoctorRequestValidator : IAddDoctorRequestValidator
    {
        private readonly PatientBookingContext _context;
        private readonly Regex _emailRegex;

        public AddDoctorRequestValidator(PatientBookingContext context)
        {
            _context = context;
            _emailRegex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", RegexOptions.Compiled);
        }

        public PdrValidationResult ValidateRequest(AddDoctorRequest request)
        {
            var result = new PdrValidationResult(true);

            if (MissingRequiredFields(request, ref result))
                return result;

            if (InvalidEmailAddress(request, ref result))
                return result;

            if (DoctorAlreadyInDb(request, ref result))
                return result;

            return result;
        }

        public bool InvalidEmailAddress(AddDoctorRequest request, ref PdrValidationResult result)
        {
            if (_emailRegex.IsMatch(request.Email)) return false;

            result.Errors.Add("Email must be a valid email address");
            result.PassedValidation = false;
            return true;
        }

        public bool MissingRequiredFields(AddDoctorRequest request, ref PdrValidationResult result)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(request.FirstName))
                errors.Add("FirstName must be populated");

            if (string.IsNullOrEmpty(request.LastName))
                errors.Add("LastName must be populated");

            if (string.IsNullOrEmpty(request.Email))
                errors.Add("Email must be populated");

            if (errors.Any())
            {
                result.PassedValidation = false;
                result.Errors.AddRange(errors);
                return true;
            }

            return false;
        }

        private bool DoctorAlreadyInDb(AddDoctorRequest request, ref PdrValidationResult result)
        {
            if (_context.Doctor.Any(x => x.Email == request.Email))
            {
                result.PassedValidation = false;
                result.Errors.Add("A doctor with that email address already exists");
                return true;
            }

            return false;
        }
    }
}
