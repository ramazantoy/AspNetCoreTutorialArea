namespace Project_8.CQRS.CQRS.Commands
{
    public class RemoveStudentCommand
    {
        public int Id { get; set; }
        
        public RemoveStudentCommand(int ıd)
        {
            Id = ıd;
        }


    }
}