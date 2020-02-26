using Microsoft.AspNetCore.Components;
using PirateApp.BussinesLogic;
using PirateApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPiratesGrid.Pages
{
    public class PirateDetailsBase : ComponentBase
    {

        [Inject]
        public IPirateService pirateService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string PirateId { get; set; }
        [Parameter]
        public int NumberOfSayings { get; set; }
        [Parameter]
        public int NumberOfDuels { get; set; }

        protected void IncrementNumberOfSayings()
        {
            var index = NumberOfSayings;
            if (index < Pirate.Sayings.Count)
            {
                Pirate.Sayings = Pirate.Sayings.Take(index).ToList();
            }
            else
            {
                for (int i = Pirate.Sayings.Count; i < index; i++)
                {
                    Pirate.Sayings.Add(new Saying() { Pirate = Pirate });
                }
            }
        }

        protected void IncrementNumberOfDuels()
        {
            var index = NumberOfSayings;
            if (index < Pirate.Sayings.Count)
            {
                Pirate.Sayings = Pirate.Sayings.Take(index).ToList();
            }
            else
            {
                for (int i = Pirate.Sayings.Count; i < index; i++)
                {
                    Pirate.Sayings.Add(new Saying() { Pirate = Pirate });
                }
            }
        }


        [Parameter]
        public Pirate Pirate { get; set; } = new Pirate() { Ship = new Ship(), Crew = new Crew() };

        protected override async Task OnInitializedAsync()
        {
            if (PirateId != null)
            {
                Pirate = await pirateService.GetPirateDetailsAsync
    (int.Parse(PirateId));

                NumberOfDuels = Pirate.PirateDuels.Count;
                NumberOfSayings = Pirate.Sayings.Count;
            }

            //return base.OnInitializedAsync();
        }





        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Pirate.Id == 0) //new
            {
                var addedEmployee = await pirateService.
                    AddPirateAsync(Pirate);

                if (addedEmployee != 0)
                {
                    StatusClass = "alert-success";
                    Message = "Nowy Pirat został dodany poprawnie";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Coś poszło nie tak z tym nowym Piratem";
                    Saved = false;
                }
            }
            else
            {
                await pirateService.UpdatePirateAsync(Pirate);
                StatusClass = "alert-success";
                Message = "Pirat zaktualizowany poprawnie.";
                Saved = true;
            }
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
