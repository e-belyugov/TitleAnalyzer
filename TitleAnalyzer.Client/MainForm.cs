using System;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TitleAnalyzer.Domain.Abstract;
using TitleAnalyzer.Domain.Entities;
using System.Collections.Generic;

namespace TitleAnalyzer.Client
{
    public partial class MainForm : Form
    {
        /// Fields for working interfaces
        private IPageRepository _repo;
        private ISimilarityCalculator _calculator;
        private IImageTitleAnalyzer _analyzer;
        private IList<TitleSimilarity> _similarities;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form loading
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Resolving objects 
            var container = new WindsorContainer();

            container.Register(Component.For<IPageRepository>().ImplementedBy<JsonPageRepository.JsonPageRepository>());
            container.Register(Component.For<ISimilarityCalculator>().ImplementedBy<LevenshteinCalculator.LevenshteinCalculator>());
            container.Register(Component.For<IImageTitleAnalyzer>().ImplementedBy<MyAnalyzer.MyAnalyzer>());

            _repo = container.Resolve<IPageRepository>();
            _calculator = container.Resolve<ISimilarityCalculator>();
            _analyzer = container.Resolve<IImageTitleAnalyzer>();
        }

        /// <summary>
        /// "Analyze" button
        /// </summary>
        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            buttonAnalyze.Text = "Loading and processing data. Please wait..";
            buttonAnalyze.Enabled = false;

            // Loading data
            _repo.Load(new Location { latitude = 37.786971, longitude = -122.399677 });
            //_repo.Load(new Location { latitude = 60.185462, longitude = 24.812390 });
            //_repo.Load(new Location { latitude = 38.925856, longitude = -77.048522 });

            // Calculating similarities
            _similarities = _analyzer.GetSimilarities();

            // Displaying similarities
            listBoxSimilarities.Items.Clear();
            int topCount = 50;
            for (int i = 0; i <= _similarities.Count; i++)
            {
                if (i <= topCount-1)
                {
                    listBoxSimilarities.Items.Add(_similarities[i].Title1);
                    listBoxSimilarities.Items.Add(_similarities[i].Title2);
                    listBoxSimilarities.Items.Add(new String('-', 150));
                }
                else
                {
                    break;
                }
            }

            buttonAnalyze.Text = "Click to analyze data";
            buttonAnalyze.Enabled = true;
        }
    }
}
