namespace Bokunda.Preslovitelj.Domain;
public class BaseEntity
{
    public long Id { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; }
    public DateTimeOffset UpdatedOn { get; private set; }

    public void SetCreatedOn(DateTimeOffset createdOn) => CreatedOn = createdOn;
    public void SetUpdatedOn(DateTimeOffset updatedOn) => UpdatedOn = updatedOn;
}

