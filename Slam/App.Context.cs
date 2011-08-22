using System;

namespace ApplicationContext
{
    /// <summary>
    /// AppContext it's a easy-simple-helper class that implement a singleton,
    /// and help to get the objects for the application.
    /// </summary>
    public class AppContext
    {
        /// <summary>
        /// Object that gonna content the context of the app
        /// </summary>
        private Spring.Context.IApplicationContext _SpringContext = null;

        /// <summary>
        /// Needed recursive declaration to implement a singleton
        /// </summary>
        private static AppContext _AppContext;



        private AppContext()
        {
            try
            {
                this._SpringContext = Spring.Context.Support.ContextRegistry.GetContext();
            }
            catch (Exception)
            {
                throw new Exception("No se puede acceder al contexto de la aplicación.");
            }

        }

        /// <summary>
        /// Provide a Unique instance of AppContext
        /// </summary>
        public static AppContext Instance
        {
            get
            {

                if (_AppContext == null)
                {
                    _AppContext = new AppContext();
                }

                return _AppContext;

            }
        }

        /// <summary>
        /// Return a instance of object in the context by a given name
        /// </summary>
        /// <param name="objectName">Name of the solicited object</param>
        /// <returns>A instance of the object, in other case an exception</returns>
        public object GetObject(string objectName)
        {
            return this._SpringContext.GetObject(objectName);
        }


    }
}