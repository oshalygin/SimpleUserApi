namespace UserResource
{
    public class Mapper : IMapper
    {
        public TOut Map<TIn, TOut>(TIn instance)
        {
            return AutoMapper.Mapper.Map<TOut>(instance);
        }

        public TOut Map<TOut>(object instance)
        {
            return AutoMapper.Mapper.Map<TOut>(instance);
        }
    }
}