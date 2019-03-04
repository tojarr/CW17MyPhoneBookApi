using MyPhoneBookApi.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MyPhoneBookApi.Models
{
    public class Contact:IEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$")]
        public string LastName { get; set; }

        public List<string> PhoneNumbers { get; set; }

        public Guid GroupId { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
    }
}