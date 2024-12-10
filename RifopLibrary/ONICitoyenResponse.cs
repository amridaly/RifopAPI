using System.Text.Json.Serialization;

namespace RifopLibrary
{
    public class ONICitoyenData
    {

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("pid")]
        public string NINU { get; set; }

        [JsonPropertyName("oldNIN")]
        public string OldNIN { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("residenceCodLoc")]
        public string ResidenceCodLoc { get; set; }

        [JsonPropertyName("residenceAddress")]
        public string ResidenceAddress { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("countryOfBirth")]
        public string CountryOfBirth { get; set; }

        [JsonPropertyName("departmentOfBirth")]
        public string DepartmentOfBirth { get; set; }

        [JsonPropertyName("communeOfBirth")]
        public string CommuneOfBirth { get; set; }

        [JsonPropertyName("placeOfBirthAbroad")]
        public string PlaceOfBirthAbroad { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("docNo")]
        public List<string> DocNo { get; set; }

    }

    public class ErrorDetail
    { 
        [JsonPropertyName("message_error")] 
        public string MessageError { get; set; }

        [JsonPropertyName("code_error")]
        public int CodeError { get; set; }
    }

    public class ONIImageResponse
    {
        public string Data { get; set; }
        public string Error { get; set; }
    }



}
