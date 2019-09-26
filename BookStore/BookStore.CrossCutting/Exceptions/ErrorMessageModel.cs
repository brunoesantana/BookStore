namespace BookStore.CrossCutting.Exceptions
{
    class ErrorMessageModel
    {
        public ErrorMessageModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
