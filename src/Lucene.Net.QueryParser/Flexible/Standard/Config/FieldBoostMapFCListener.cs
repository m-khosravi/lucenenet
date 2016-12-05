﻿using Lucene.Net.QueryParsers.Flexible.Core.Config;
using System.Collections.Generic;

namespace Lucene.Net.QueryParsers.Flexible.Standard.Config
{
    /*
     * Licensed to the Apache Software Foundation (ASF) under one or more
     * contributor license agreements.  See the NOTICE file distributed with
     * this work for additional information regarding copyright ownership.
     * The ASF licenses this file to You under the Apache License, Version 2.0
     * (the "License"); you may not use this file except in compliance with
     * the License.  You may obtain a copy of the License at
     *
     *     http://www.apache.org/licenses/LICENSE-2.0
     *
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     */

    /// <summary>
    /// This listener listens for every field configuration request and assign a
    /// {@link ConfigurationKeys#BOOST} to the
    /// equivalent {@link FieldConfig} based on a defined map: fieldName -> boostValue stored in
    /// {@link ConfigurationKeys#FIELD_BOOST_MAP}.
    /// </summary>
    /// <seealso cref="ConfigurationKeys#FIELD_BOOST_MAP"/>
    /// <seealso cref="ConfigurationKeys#BOOST"/>
    /// <seealso cref="FieldConfig"/>
    /// <seealso cref="IFieldConfigListener"/>
    public class FieldBoostMapFCListener : IFieldConfigListener
    {
        private QueryConfigHandler config = null;

        public FieldBoostMapFCListener(QueryConfigHandler config)
        {
            this.config = config;
        }

        public virtual void BuildFieldConfig(FieldConfig fieldConfig)
        {
            IDictionary<string, float?> fieldBoostMap = this.config.Get(ConfigurationKeys.FIELD_BOOST_MAP);

            if (fieldBoostMap != null)
            {
                float? boost;
                if (fieldBoostMap.TryGetValue(fieldConfig.Field, out boost) && boost != null)
                {
                    fieldConfig.Set(ConfigurationKeys.BOOST, boost);
                }
            }
        }
    }
}