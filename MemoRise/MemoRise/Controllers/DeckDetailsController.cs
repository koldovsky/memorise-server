using System.Web.Http;
using MemoBll;
using MemoDTO;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;

namespace MemoRise.Controllers
{
    public class DeckDetailsController : ApiController
    {
        DeckDetailsBll deckDetails = new DeckDetailsBll();

        [HttpGet]
        [Route("DeckDetails/GetDeckWithDetails/{deckName}")]
        public HttpResponseMessage GetDeckWithDetails(string deckName)
        {
            try
            {
                DeckWithDetailsDTO deckWithDetailsDTO = deckDetails.GetDeckWithDetails(deckName);
                return Request.CreateResponse(HttpStatusCode.OK, deckWithDetailsDTO);
            }
            catch (ArgumentNullException ex)
            {
                var message = $"Deck with name = {deckName} not found. {ex.Message}";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, err);
            }
        }
    }
}
