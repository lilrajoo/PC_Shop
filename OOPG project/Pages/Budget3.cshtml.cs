using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;

namespace OOPG_project.Pages
{
    public class Budget3Model : PageModel
    {
        private float ramCost;
        

        [BindProperty]
        [Required(ErrorMessage = "You must enter your name")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter your contact number")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Please enter a valid 8-digit phone number")]
        public string ContactNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter your address")]
        public string Address { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must select a delivery date")]
        public DateTime DeliveryDate { get; set; }

        [BindProperty]
        public float TotalCost { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a valid PC option")]
        public string SelectedPCOption { get; set; }

        [BindProperty]
        public bool AddRam { get; set; }

        [BindProperty]
        public bool AddRGB { get; set; }

        [BindProperty]
        public bool AddWaterCooling { get; set; }

        public void OnGet()
        {

            DeliveryDate = DateTime.Now;
        }

        public IActionResult OnPost()
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                // If not valid, return the page with validation errors
                return Page();
            }
            if (DeliveryDate < DateTime.Now.AddDays(7))
            {
                ModelState.AddModelError("DeliveryDate", "Please pick a delivery date at least 7 days away.");
                return Page();
            }
            // Reset total cost to zero before calculating
            TotalCost = 0.0f;

            string PCTier = SelectedPCOption;

            int ram = 0;
            ramCost = 0.0f;

            // Calculate total cost based on selected PC option
            if (PCTier == "Low-end")
            {
                TotalCost = 901.00f;
                ram = 16;
                ramCost = 100.00f;
            }
            else
            {
                TotalCost = 1250.00f;
                ram = 32;
                ramCost = 250.00f;
            }

            // Calculate cost for additional RAM if selected
            if (AddRam)
            {
                ram *= 2;
                TotalCost += 2 * ramCost;
            }
            else
            {
                TotalCost += ramCost;
            }

            // Add additional costs for RGB and Water Cooling if selected
            if (AddRGB)
            {
                TotalCost += 50.00f;
            }

            if (AddWaterCooling)
            {
                TotalCost += 200.00f;
            }

            // Add 9% GST to the total cost
            TotalCost += TotalCost * 0.09f;

            // Return the page
            return Page();
        }

    }
}
