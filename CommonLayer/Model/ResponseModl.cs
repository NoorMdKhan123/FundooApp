using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{/// <summary>
 /// This is a ResponseModel class
 /// </summary>
 /// <typeparam name="T">It represents a generic data type</typeparam>
    public class ResponseModl<T>
    {
        /// <summary>
        ///  Gets or sets a value indicating whether a particular functionality is executed
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether a particular functionality is executed
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a particular Get API is implemented
        /// </summary>
        public T Data { get; set; }
    }
}
