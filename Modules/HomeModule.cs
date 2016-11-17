using Nancy;
using System.Collections.Generic;
using Hangman.Objects;

namespace Hangman
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>{
        State newState = new State();
        newState.MakeBlanks();
        newState.SetBlankString();
        System.Console.WriteLine(newState.GetComputerWord());
        return View["index.cshtml", newState];
      };
      Post["/"] = _ =>{
        List<State> states = State.GetStates();
        State state = states[states.Count-1];
        string letter = Request.Form["letter"];
        state.SetCurrentLetter(letter);
        state.SetLettersGuessed();
        state.SetGuessesLeft();
        state.CheckLetter();
        state.SetBlankString();
        return View["index.cshtml", state];
      };
    }
  }
}
