namespace Meetings.Services.Interface
{
    public interface IOperatorService
    {
        bool AddOperator(long operator_id, string name);
        bool EditOperator(long id, long operator_id, string name);
        bool RemoveOperator(long id);
    }
}
