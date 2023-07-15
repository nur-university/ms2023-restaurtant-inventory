using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;

namespace Restaurant.Inventory.Domain.Model.Items;

public record ItemName : ValueObject
{
    public string Value { get; init; }

    internal ItemName(string value)
    {
        CheckRule(new StringNotNullOrEmptyRule(value));
        Value = value;
    }

    public static implicit operator string(ItemName itemName) => itemName.Value;

    public static implicit operator ItemName(string itemName) => new(itemName);
}
