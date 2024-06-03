using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using System.Net;

namespace Deck_of_Cards_Lab.Models
{
    public class DeckDAL
    {
        public static DeckModel GetDeck()
        {
            
            string url = $"https://deckofcardsapi.com/api/deck/new/";
            
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON);
            return result;
        }
        public static DeckModel ShuffleDeck()
        {

            string url = $"https://deckofcardsapi.com/api/deck/u70glh0db5as/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON);
            return result;
        }
        public static DeckModel DrawCard()
        {

            string url = $"https://deckofcardsapi.com/api/deck/u70glh0db5as/draw/?count=5";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON);
            return result;
        }
    }
}
