namespace Application.Commands.Orders.Create
{
    /// <summary>
    /// Represents the response returned after successfully creating a new Order.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created Order,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateOrderResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created Order.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created Order in the system.</value>
        public Guid Id { get; set; }
    }
}
