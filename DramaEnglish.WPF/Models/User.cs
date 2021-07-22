using Newtonsoft.Json;

namespace DramaEnglish.WPF.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public int Id { get; set; }


        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        

    }
}
