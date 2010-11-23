﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard.Settings;

namespace Orchard.Localization.Services {
    public class CurrentCultureWorkContext : IWorkContextStateProvider {
        private readonly ICultureManager _cultureManager;

        public CurrentCultureWorkContext(ICultureManager cultureManager) {
            _cultureManager = cultureManager;
        }

        public Func<WorkContext, T> Get<T>(string name) {
            if (name == "CurrentCulture") {
                return ctx => (T)(object)_cultureManager.GetCurrentCulture(ctx.HttpContext);
            }
            return null;
        }
    }
}