using MyMicroservice.Domain;

namespace MyMicroservice.Infrastructure;

public class Operation : IOperation
{
    public string OperationAction(string id)
    {
       return Guid.NewGuid().ToString("N");
    }
}
public class GenericService<T> : IGenericService<T>
{
    public T Data { get; private set; }
    public GenericService(T data)
    {
        this.Data = data;
    }
}