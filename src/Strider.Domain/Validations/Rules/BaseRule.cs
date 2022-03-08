namespace Strider.Domain.Validations.Rules
{
    public abstract class BaseRule<TModel>
    {
        public readonly List<string> erros = new List<string>();

        public List<string> Validate(TModel model)
        {
            VerifyRule(model);
            return erros;
        }

        protected List<string> AddError(string error)
        {
            erros.Add(error);
            return erros;
        }

        protected abstract void VerifyRule(TModel model);
    }
}
