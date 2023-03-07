namespace Srv.Crud.Domain.Responses.CommandResponses
{
    public class CreateTokenResponse
    {       
        public string AccessToken { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
