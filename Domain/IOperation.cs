
namespace MyMicroservice.Domain;

public interface IOperation
{
    string OperationAction(string id);
    
}

public interface IGenericService<T>
{

}