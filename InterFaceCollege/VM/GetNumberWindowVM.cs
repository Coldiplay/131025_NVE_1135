using InterFaceCollege.VM.VMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceCollege.VM
{
    public class GetNumberWindowVM : BaseVM
    {
        private int num;

        public int Num
        {
            get => num;
            set
            {
                num = value;
                Signal();
            }
        }

        public GetNumberWindowVM()
        {
            
        }
    }
}
