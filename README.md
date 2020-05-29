# Push Doctor - Technical Test

## Worked example

I think the doc could be restructured to be clearer - there's a lot to wade through here and I think less is more

---

- Introduction
- Solution: Domain
  - Currently as System Overview - Terminology
- Solution: Implementation
  - Other quirks is useful
  - Packages isn't really adding anything

If all this can be slimmed down to a single page that would be good: the domain described as a diagram or something perhaps

A lot of words makes this a chore before they've even got to the actual task. Phrases like *In a fully developed system, the patient would be...* are a bit... meh and make it sound like we're pitching this as a school room task rather than a tool to see how a developer with at least some experience tackles the problems.

---

- Task
  - Ticket 1
  - Ticket 2
    - this is actually 2 tickets and it doesn't really make sense as one
  - Ticket 3
    - This is very prescriptive...

I can see the intent

- a *fix stuff* ticket
- a *make something that exists better* ticket
- an *add something new* ticket

If we're pitching this at any level above a junior dev then I think it's all a bit noddy. I'd quite like to see this be a bit more open to their interpretation - and a *why don't you refactor this solution in your own image* would be good to give them a bit of space to play.

While I can see the benefit of a domin specific code test... by providing the starting point we've already constrained how they can express themselves in code.

---

#### Starting point

`We’d like you to submit your work as a github repository (or other public source control provider repository) where possible. As you complete the exercise we’d like you to commit regularly, with appropriate commit messages so that we can gain an understanding of the process you used to reach your eventual solution.`

`If you are not able to provide a link to a repository, then a zip file of the project will suffice.`

I'm on a work machine, I don't want to do this as my existing work git user - so I've spent a lot of time fettling to get to a state where I can do this correctly and not impact on my actual work.

What we want is an understanding of how they approach the dev work: We tell them how we like dev work to be approached, and not what our goal is here *'...we’d like you to commit regularly, with appropriate commit messages..'* so I think this wording of this is off. I'd suggest something a bit more:

`We'd like to see how you approach development using source control. Submitting as a git repo, where we can look at your individual commits for example, would be ideal. Whether or not your submission includes source control we will want a discussion about that`

---

### Test Bugs ###

1. Bug **AddDoctor_AddsDoctorToContextWithGeneratedId**

   ​	This is horrid - and what does it actually tell us?

2. Bug  **ValidateRequest_InvalidEmail_ReturnsFailedValidationResult**

   ​	Nice

3. Bug **AddPatient_AddsPatientToContextWithGeneratedId**

   ​	This is just bug 1 for a different entity so it really doesn't tell us anything

4. Bug **ValidateRequest_InvalidEmail_ReturnsFailedValidationResult**

   ​	Ditto bug 2

5. Bug **ValidateRequest_ClinicDoesNotExist_ReturnsFailedValidationResult**

   ​	/me shrugs