namespace Tmdb.Core.Notification
{
    public class DomainNotification : Exception
    {
        internal List<string> _erros;
        public IReadOnlyCollection<string> Erros => _erros;

        public DomainNotification() { }

        public DomainNotification(string message, List<string> errors) : base(message)
        {
            _erros = errors;
        }

        public DomainNotification(string message) : base(message)
        { }

        public DomainNotification(string message, Exception innerException) : base(message, innerException) { }
    }
}