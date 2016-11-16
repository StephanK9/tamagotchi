using Nancy;
using System.Collections.Generic;
using Pet.Objects;

namespace Pet
{
  public class HomeModule : NancyModule
  {
    public HomeModule(){


      Get["/"] = _ =>{
        return View["index.cshtml"];
      };
      Get["/dead"] = _ =>{
        return View["dead.cshtml"];
      };
      Post["/tamagotchi-base"] = _ =>{
        Tamagotchi newTamagotchi = new Tamagotchi(Request.Form["new-name"]);
        return View["tamagotchi_base.cshtml", newTamagotchi];
      };
      Post["/feed/{id}"] = parameters =>{
          Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
          tamagotchi.SetHunger();
          if(tamagotchi.Check())
          {
            return View["/dead.cshtml"];
          }
          else{
            return View["/tamagotchi.cshtml", tamagotchi];
          }
      };
      Post["/play/{id}"] = parameters =>{
          Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
          tamagotchi.SetBoredom();
          if(tamagotchi.Check())
          {
            return View["/dead.cshtml"];
          }
          else{
            return View["/tamagotchi.cshtml", tamagotchi];
          }
          return View["/tamagotchi.cshtml", tamagotchi];
      };
      Post["/rest/{id}"] = parameters =>{
          Tamagotchi tamagotchi = Tamagotchi.Find(parameters.id);
          tamagotchi.SetRest();
          if(tamagotchi.Check())
          {
            return View["/dead.cshtml"];
          }
          else{
            return View["/tamagotchi.cshtml", tamagotchi];
          }
          return View["/tamagotchi.cshtml", tamagotchi];
      };
    }
  }
}
