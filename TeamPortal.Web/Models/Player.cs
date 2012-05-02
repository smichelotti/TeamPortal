using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TeamPortal.Web.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public int TeamId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        public string PhotoUri { get; set; }
        
        [DataType(DataType.ImageUrl)]
        [DisplayName("Photo")]
        public string PhotoToUpload { get; set; }
        
        [DisplayName("Jersey #")]
        public int? JerseyNumber { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
        
        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        
        [DisplayName("State")]
        public int StateId { get; set; }
        
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

    }
}