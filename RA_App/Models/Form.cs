using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RA_App.Models
{
    public class Form
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "The type of report is required")]
        [DisplayName("Type of Report")]
        public string TOR { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "Name should be between 2 to 40 Characters")]
        [Required(ErrorMessage = "The student name is required")]
        [DisplayName("Student Name")]
        public string StudName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname should be between 2 to 50 Characters")]
        [Required(ErrorMessage = "The student surname is required")]
        [DisplayName("Student Surname")]
        public string StudSurname { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Please enter a valid student number (8 Digits)")]
        [Required(ErrorMessage = "Student number is required")]
        [DisplayName("Student Number")]
        public string StudNo { get; set; }

        [Required(ErrorMessage = "The student's year of study is required")]
        [DisplayName("Year of Study")]
        public int YOS { get; set; }                                                      //which year they are in

        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please enter a valid phone number")]
        [Required(ErrorMessage = "The student's contact number is required")]
        [DisplayName("Contact Number")]
        public string ContactNo { get; set; }


        [Required(ErrorMessage = "The Nature Of Incident / Illness is required")]
        [DisplayName("Nature Of Incident / Illness")]
        public string NatureOf_II { get; set; }                                           //text message from RA


        [Required(ErrorMessage = "The date Of Incident / Illness is required")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Incident / Illness")]
        public DateTime Dateof_II { get; set; }

        [Required(ErrorMessage = "The date Of Incident / Illness reported to RA is required")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Incident / Illness Reported To RA")]
        public DateTime DateReported_II { get; set; }

        [Required(ErrorMessage = "The details Of Incident / Illness is required")]
        [DisplayName("Details of Incident / Illness")]
        public string Details_II { get; set; }                                            //text message from RA

        [Required(ErrorMessage = "Actions taken is required")]
        [DisplayName("Actions Taken (If The Ambulance Was Called, Please Indicate)")]
        public string ActionsTaken { get; set; }                                          //text message from RA

        [Required(ErrorMessage = "Recommendations is required")]
        [DisplayName("Recommendations")]
        public string Recommendations { get; set; }                                      //text message from RA


        public string UserName { get; set; }


        [DisplayName("Residence Advisor")]
        public string Emp_Name { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}