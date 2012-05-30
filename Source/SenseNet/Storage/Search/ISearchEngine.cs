﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SenseNet.ContentRepository.Storage.Data;

namespace SenseNet.ContentRepository.Storage.Search
{
    public interface IIndexDocumentProvider
    {
        object GetIndexDocumentInfo(Node node);
    }
    public interface ISearchEngine
    {
        bool IndexingPaused { get; }

        IIndexPopulator GetPopulator();

        IEnumerable<int> Execute(NodeQuery nodeQuery);
        IDictionary<string, Type> GetAnalyzers();

        void SetIndexingInfo(object indexingInfo);
    }
    public class InternalSearchEngine : ISearchEngine
    {
        public static InternalSearchEngine Instance = new InternalSearchEngine();

        public bool IndexingPaused { get { return false; } }

        public IIndexPopulator GetPopulator()
        {
            return NullPopulator.Instance;
        }
        public IEnumerable<int> Execute(NodeQuery nodeQuery)
        {
            throw new NotSupportedException();
        }
        public IDictionary<string, Type> GetAnalyzers()
        {
            return null;
        }
        public void SetIndexingInfo(object indexingInfo)
        {
            // do nothing
        }
    }

}