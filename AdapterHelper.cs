using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Optomo
{
	public class AdapterHelper<T, U> 
	{	
		private Func<T, U> m_Transformer;
		public T Source { get; set; }
		public U Target { get; set; }

		private AdapterHelper( Func<T, U> transformer )
		{
			m_Transformer = transformer;
		}
		public AdapterHelper( Func<T, U> transformer, T source ) : this(transformer)
		{
			this.Source = source;
			this.Target = Transform(source);
		}
		public AdapterHelper( Func<T, U> transformer, T source, U target ) : this( transformer )
		{
			this.Source=source;
			this.Target=target;
		}

		public U Transform (T input)
		{
			return m_Transformer(input);
		}
		public U[] TransformArray (T[] inputs) 
		{
			U[] result = new U[inputs.Length];

			for (uint i = 0; i < inputs.Length; i++) 
			{
				result[i] = m_Transformer(inputs[i]);
			}
			return result;
		}
		public static U Transform (T source, Func<T, U> transformFunc)
		{
			return transformFunc.Invoke(source);
		}
		public static U [] TransformArray( T [] inputs, Func<T, U> transformFunc )
		{
			U[] result = new U[inputs.Length];

			for ( uint i = 0; i < inputs.Length; i++ )
			{
				result [ i ] = transformFunc.Invoke( inputs [ i ] );
			}
			return result;
		}
	}
}
