using System;

namespace IndoAsCompras.Dominio.Entidades
{
    public class Item
    {
        #region Atributos

        private Nullable<long> id;
        private string nome;
        private float quantidade;
        private float precoUnitario;
        private bool ehpromocao;
        private TipoPromocao tipoPromocao;
        private float subtotal;

        //Relacionamentos

        private ListaDeCompra listaDeCompra;
        private Mercado mercado;
        private Categoria categoria;
        private Unidade unidade;

        #endregion

        #region Construtores
        public Item()
        {

        }

        public Item(Nullable<long> id,string nome,float quantidade,float precoUnitario,bool ehpromocao,
            TipoPromocao tipoPromocao)
        {
            this.id = id;
            this.nome = nome;
            this.quantidade = quantidade;
            this.precoUnitario = precoUnitario;
            this.ehpromocao = ehpromocao;
            this.tipoPromocao = tipoPromocao;
            this.subtotal = quantidade * precoUnitario;
        }
        #endregion

        #region Propriedades

        public virtual Nullable<long> Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }
        
        public virtual string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                this.nome = value;
            }
        }

        public virtual float Quantidade
        {
            get
            {
                return quantidade;
            }
            set
            {
                this.quantidade = value;
            }
        }

        public virtual float PrecoUnitario
        {
            get
            {
                return precoUnitario;
            }
            set
            {
                this.precoUnitario = value;
            }
        }

        public virtual float Subtotal
        {
            get
            {
                subtotal = quantidade * precoUnitario;
                return subtotal;
            }
            private set
            {
                subtotal = value;
            }
        }

        public virtual bool EhPromocao
        {
            get
            {
                return ehpromocao;
            }
            set
            {
                ehpromocao = value;
            }
        }

        public virtual TipoPromocao TipoPromocao
        {
            get
            {
                return TipoPromocao;
            }
            set
            {
                this.tipoPromocao = value;
            }
        }

        public virtual ListaDeCompra ListaDeCompra
        {
            get
            {
                return listaDeCompra;
            }
            set
            {
                this.listaDeCompra = value;
            }
        }
        public virtual Mercado Mercado
        {
            get
            {
                return mercado;
            }
            set
            {
                this.mercado = value;
            }
        }
        public virtual Categoria Categoria
        {
            get
            {
                return categoria;
            }
            set
            {
                this.categoria = value;
            }
        }
        public virtual Unidade Unidade
        {
            get
            {
                return unidade;
            }
            set
            {
                unidade = value;
            }
        }
        #endregion

        #region Métodos

        #endregion

        #region Sobrescritas do Papai

        /// <summary>
        /// Provê igualdade entre classes de mesmo tipo de Item
        /// </summary>
        /// <param name="o">Objeto a ser verificada a igualdade</param>
        /// <returns>true => se for igual e false => se for diferente</returns>			
        public override bool Equals(object o)
        {
            if (o.GetType().IsAssignableFrom(GetType()))
            {
                BindingFlags visibilidadePermitida = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
                FieldInfo[] classeLocal = typeof(Item).GetFields(visibilidadePermitida);
                FieldInfo[] classeExterna = o.GetType().GetFields(visibilidadePermitida);

                int totalDeCamposLocais = classeLocal.Select(cl => cl.GetValue(this)).ToList().Count;
                int totalDeCamposExternos = classeExterna.Select(ce => ce.GetValue(this)).ToList().Count;

                var atributos = typeof(Item).GetFields(visibilidadePermitida).Select(u => u.GetValue(this)).ToList();

                if ((classeLocal != null && totalDeCamposLocais > 0) && classeExterna != null && totalDeCamposExternos > 0)
                {

                    var igualdade = (from l in classeLocal
                                     from e in classeExterna
                                     where l.Name == e.Name && l.GetValue(this) == e.GetValue(this)
                                     select l).ToList();

                    if (igualdade != null && igualdade.Count.Equals(totalDeCamposLocais))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// A hash code is a numeric value that is used to insert and identify an object in a hash-based collection
        /// such as the Dictionary<TKey, TValue> class, the Hashtable class,or a type derived from the DictionaryBase class.
        /// Two objects that are equal return hash codes that are equal.
        /// </summary>
        /// <returns>O valor do hash gerado ou 0 para a Classe DocumentoArquivistico</returns>
        public override int GetHashCode()
        {
            BindingFlags visibilidadePermitida = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

            int resultado = new Random().Next(0, DateTime.Now.Hour);

            //Pega os Atributos da Classe            
            FieldInfo[] atributos = GetType().GetFields(visibilidadePermitida);

            foreach (FieldInfo atributo in atributos)
            {
                //Calcula de acordo com o tipo e o valor do campo
                switch (atributo.FieldType.Name)
                {
                    case "Boolean":
                        resultado = 31 * resultado + (bool.Parse(atributo.GetValue(this).ToString()) ? 1 : 0);
                        break;
                    case "Byte":
                        resultado = 31 * resultado + Convert.ToInt16((byte.Parse(atributo.GetValue(this).ToString())));
                        break;
                    /*case "char":
                        resultado = 31 * resultado + (char.Parse(atributo.GetValue(this).ToString()));
                        break;
                    */
                    case "Short":
                        resultado = 31 * resultado + (short.Parse(atributo.GetValue(this).ToString()));
                        break;
                    case "Int":
                        resultado = 31 * resultado + (int.Parse(atributo.GetValue(this).ToString()));
                        break;
                    case "Long":
                        resultado = 31 * resultado + int.Parse(atributo.GetValue(this).ToString()) ^ (int.Parse(atributo.GetValue(this).ToString()) >> 32);
                        break;
                    case "Float":
                        resultado = 31 * resultado + Convert.ToInt16(atributo.GetValue(this));
                        break;
                    case "Double":
                        resultado = 31 * resultado + Convert.ToInt16(double.Parse(atributo.GetValue(this).ToString())) ^ (Convert.ToInt16(double.Parse(atributo.GetValue(this).ToString())) >> 32);
                        break;
                }

                switch (atributo.FieldType.FullName)
                {
                    case "System.Nullable`1[System.Int64]":
                        resultado = 31 * resultado + (int.Parse(atributo.GetValue(this).ToString()));
                        break;

                    case "System.Nullable`1[System.Int32]":
                        resultado = 31 * resultado + int.Parse(atributo.GetValue(this).ToString()) ^ (int.Parse(atributo.GetValue(this).ToString()) >> 32);
                        break;
                }
            }
            //// Objects

            //resultado = 31 * resultado + Arrays.hashCode(arrayField);              // var bits » 32-bit

            //resultado = 31 * resultado + referenceField.hashCode();                // var bits » 32-bit (non-nullable)   
            //resultado = 31 * resultado +                                           // var bits » 32-bit (nullable)   
            //    (nullableReferenceField == null
            //        ? 0
            //        : nullableReferenceField.hashCode());

            //return resultado;
            return resultado;
        }

        /// <summary>
        /// Mostra a saída formatada dos valores presentes
        /// nos atributos de Item
        /// </summary>
        /// <returns>Uma string contendo os valores dos atributos da Classe Incluindo seus relacionamentos</returns>
        public override string ToString()
        {
            BindingFlags visibilidadePermitida = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            StringBuilder builder = new StringBuilder();

            //Pega os Atributos da Classe            
            FieldInfo[] atributos = GetType().GetFields(visibilidadePermitida);
            builder.Append("[ ");
            foreach (FieldInfo campo in atributos)
            {
                builder.Append(String.Format("{0} => {1} ", campo.Name, campo.GetValue(this)));
            }

            builder.Append(" ] ");
            return !String.IsNullOrEmpty(builder.ToString()) ? builder.ToString() : String.Empty;
        }
        #endregion

    }
}
