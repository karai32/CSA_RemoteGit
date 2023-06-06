using System;
using System.Collections.Generic;
using System.Linq;
using KlientServ.Storage;
using KlientServ.Models;

namespace KlientServ.Storage
{
    public class MemCache : IStorage<Phone>
    {
        private object _sync = new object();
        private List<Phone> _MEM = new List<Phone>();
        public Phone this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectLabDataException($"No LabData with id {id}");

                    return _MEM.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectLabDataException("Cannot request LabData with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _MEM.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<Phone> All => _MEM.Select(x => x).ToList();

        public void Add(Phone value)
        {
            if (value.Id == Guid.Empty) throw new IncorrectLabDataException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _MEM.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _MEM.RemoveAll(x => x.Id == id);
            }
        }
    }
}