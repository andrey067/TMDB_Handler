namespace Tmdb.Core.Notification
{
    public class DomainNotification
    {
        internal List<string> _erros;
        public IReadOnlyCollection<string> Erros => _erros;

        public DomainExceptions() { }

        public DomainExceptions(string message, List<string> errors) : base(message)
        {
            _erros = errors;
        }

        public DomainExceptions(string message) : base(message)
        { }

        public DomainExceptions(string message, Exception innerException) : base(message, innerException) { }
    }
}