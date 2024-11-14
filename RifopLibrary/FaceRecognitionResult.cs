using System.Text.Json.Serialization;

namespace RifopLibrary
{
    //réponses possibles:
    //1- {data=[{identitiy=,currentPhoto=,Score}], error=}
    //2 - {identitiy=,currentPhoto=,Score}

    public class FaceRecognitionResult
    {
        [JsonPropertyName("identitiy")]
        public ONICitizenIdentity Identity { get; set; }

        [JsonPropertyName("currentPhoto")]
        public ONICitizenPhoto CurrentPhoto { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }
    }

    public class ONICitizenIdentity
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("pid")]
        public long NINU { get; set; }

        [JsonPropertyName("placeOfBirth")]
        public string PlaceOfBirth { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("residenceCodLoc")]
        public int ResidenceCodLoc { get; set; }

        [JsonPropertyName("residenceAddress")]
        public string ResidenceAddress { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("countryOfBirth")]
        public string CountryOfBirth { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }


    }

    public class ONICitizenPhoto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("mimeType")]
        public string MimeType { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }
    }


    /// <summary>
    /// Définit le doigt
    /// </summary>
    public enum HandFinger
    {
        /// <summary>LEFT_THUMB</summary>
        LEFT_THUMB,
        /// <summary> LEFT_INDEX</summary>
        LEFT_INDEX,
        /// <summary> LEFT_MIDDLE</summary>
        LEFT_MIDDLE,
        /// <summary> LEFT_RING</summary>
        LEFT_RING,
        /// <summary> LEFT_LITTLE</summary>
        LEFT_LITTLE,
        /// <summary> RIGHT_THUMB</summary>
        RIGHT_THUMB,
        /// <summary> RIGHT_INDEX</summary>
        RIGHT_INDEX,
        /// <summary> RIGHT_MIDDLE</summary>
        RIGHT_MIDDLE,
        /// <summary> RIGHT_RING</summary>
        RIGHT_RING,
        /// <summary> RIGHT_LITTLE</summary>
        RIGHT_LITTLE
    }
}
