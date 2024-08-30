namespace Project_8.CQRS.CQRS.Queries
{
    public class GetStudentByIdQuery
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}