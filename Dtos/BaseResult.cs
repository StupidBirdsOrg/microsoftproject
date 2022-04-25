public class BaseResult{
    public string Msg{ get; set; }
    public ResultStatus Status{ get; set; }
    public bool Success{ get=>this.Status == ResultStatus.Success; }
}
public class BaseResult<T>:BaseResult{
    public T Data { get; set; }
}

public enum ResultStatus{
    Success,
    Failure,
}