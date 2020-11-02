# Introduction
Hello there! This is a console app that allows you train your trivia skills by yourself or with a friend. All you need is Visual Studio and you're ready to sharpen or flex your skills. 

Built using .NET Core 3.1 and C# 

## To run:

1.  `git clone https://github.com/aliceluo2048/TandemTrivia.git`
2. Open `TandemTrivia.sln` in Visual Studio 2019
3. Run the `TandemTrivia` project

# Acceptance Criteria
* A user can view questions.
* Questions with their multiple choice options must be displayed one at a time.
* Questions should not repeat in a round.
* A user can select only 1 answer out of the 4 possible answers.
* The correct answer must be revealed after a user has submitted their answer
* A user can see the score they received at the end of the round

# Notes
* I would have liked to have done more unit testing on the console interactions however `System.Console` is not straightforward to mock

## Additional features that could have been implemented:
* More statistics that show users' performance over time
* User achievements or in-game interaction such as "4 correct answers in a row"
* Creative styling within a console app