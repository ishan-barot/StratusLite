
# stratuslite

a simple c# automation tool i built to handle common dotnet tasks
. nothing fancy, just gets the job done.

## what it does

basically just wraps `dotnet restore`, `dotnet build`, and `dotnet test` commands with some nice output formatting
. i got tired of typing the same commands over and over, so i made this little tool.

## features

- runs build and test tasks
- works on windows, mac, and linux (i think..
. tested on ubuntu and windows at least)
- shows command output as it runs
- proper error handling when things go wrong
- some unit tests because why not

## how to use it

you need .net 8 installed
. then:

```bash
git clone <your-repo-url>
cd stratuslite
dotnet build
```

run tasks like this:
```bash
dotnet run -- build    # does restore + build
dotnet run -- test     # runs tests
```

that's it
. pretty straightforward.

## what's inside

- `program.cs` - main entry point, handles args and prints stuff
- `taskrunner.cs` - does the actual work of running commands
- some tests in the tests folder

the code is pretty simple
. taskrunner just uses process.start to run dotnet commands and captures the output
. had to do some platform detection stuff to make it work on both windows (cmd) and unix (bash).

## testing

```bash
dotnet test
```

or use the tool itself:
```bash
dotnet run -- test
```

tests are basic but they work
. mostly just checking that invalid tasks fail properly and valid ones don't crash.

## ci/cd

there's a github actions workflow that builds and tests on multiple platforms
. it actually uses the tool itself to do the building/testing which is kinda neat (dogfooding i guess).

## why i built this

honestly just wanted a simple example project to show i can write decent c# code
. it's not groundbreaking but it demonstrates:

- process management in c#
- cross-platform development
- async/await patterns
- unit testing
- ci/cd setup
- clean code practices (mostly)

## contributing

feel free to submit prs if you want to improve something
. it's a pretty simple project so there's not much to break.

## license

mit license - do whatever you want with it.

---
built with .net 8 and a bit of caffeine 
