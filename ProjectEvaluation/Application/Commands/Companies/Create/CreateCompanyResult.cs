namespace Application.Commands.Companies.Create
{
    /// <summary>
    /// Represents the response returned after successfully creating a new Company.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created Company,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateCompanyResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created Company.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created Company in the system.</value>
        public Guid Id { get; set; }
    }
}
