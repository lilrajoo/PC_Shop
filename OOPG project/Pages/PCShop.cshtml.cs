using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

namespace OOPG_project.Pages
{
    // This class represents the model for the PCShop page using Razor Pages in ASP.NET Core.
    public class PCShopModel : PageModel
    {
        // BindProperty attribute is used to automatically bind form values to this property.
        // Required attribute ensures that the PriceRange property is not null or an empty string.
        [BindProperty]
        [Required(ErrorMessage = "You must select a price range")]
        public string PriceRange { get; set; }

        // This method is executed when the form is submitted (HTTP POST request).
        public IActionResult OnPost()
        {
            // Check if the model state is valid, i.e., if the form input passes validation.
            if (ModelState.IsValid)
            {
                // Directly redirect to the selected budget page based on the chosen price range.

                // If the selected price range is "500-750", redirect to Budget1 page.
                if (PriceRange == "500-750")
                {
                    return RedirectToPage("Budget1");
                }
                // If the selected price range is "751-1000", redirect to Budget2 page.
                else if (PriceRange == "751-1000")
                {
                    return RedirectToPage("Budget2");
                }
                // If the selected price range is "1001-1500", redirect to Budget3 page.
                else if (PriceRange == "1001-1500")
                {
                    return RedirectToPage("Budget3");
                }

                // If the selected price range does not match any predefined values, stay on the current page.
                return Page();
            }
            else
            {
                // If the model state is not valid, return the current page to display validation errors.
                return Page();
            }
        }
    }
}
