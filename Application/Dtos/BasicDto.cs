namespace Application.Dtos
{
    public class BasicDto
    {
        public BasicDto()
        {
        }

        public BasicDto(string result)
        {
            Result = result;
        }
        public string Result { get; set; }
    }
}