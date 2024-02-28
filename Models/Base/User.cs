using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ApiProject.Models.Base
{
    /// <summary>
    /// Base User 
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]

        [DataMember(Name = "id")]
        public Guid? Id { get; set; }

        [DataMember(Name = "role")]
        public string Role { get; set; } = "User";

        [JsonIgnore]
        [XmlIgnore]
        public string Password {get; set;}
    }
}