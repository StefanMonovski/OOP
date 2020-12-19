using FestivalManager.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class StageTests
    {
        Song song;
        Performer performer;
        Stage stage;

        [SetUp]
        public void SetUp()
        {
            song = new Song("name", new TimeSpan(0, 3, 30));
            performer = new Performer("firstName", "lastName", 30);
            stage = new Stage();
        }

        [Test]
        public void PerformersGetterReturnsPerformersAsReadOnlyCollection()
        {
            stage.AddPerformer(performer);
            IReadOnlyCollection<Performer> expectedResult = new List<Performer>() { performer }.AsReadOnly();
            Assert.That(stage.Performers, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddPerformerMethodThrowsExceptionIfValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

        [Test]
        public void AddPerformerMethodThrowsExceptionIfPerformerAgeIsLessThan18()
        {
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("firstName", "lastName", 16)));
        }

        [Test]
        public void AddPerformerMethodAddsPerformer()
        {
            stage.AddPerformer(performer);
            Assert.That(stage.Performers.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSongMethodThrowsExceptionIfValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }

        [Test]
        public void AddSongMethodThrowsExceptionIfSongDurationIsLessThan1minute()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("song", new TimeSpan(0, 0, 30))));
        }

        [Test]
        public void AddSongToPerformerMethodThrowsExceptionIfSongIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "performer"));
        }

        [Test]
        public void AddSongToPerformerMethodThrowsExceptionIfPerformerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("song", null));
        }

        [Test]
        public void AddSongToPerformerMethodThrowsExceptionIfPerformerDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("song", "performer"));
        }

        [Test]
        public void AddSongToPerformerMethodThrowsExceptionIfSongDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("song", "performer"));
        }

        [Test]
        public void AddSongToPerformerMethodAddsSongToPerformer()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("name", "firstName lastName");
            Assert.That(performer.SongList.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSongToPerformerMethodReturnsExpectedResult()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("name", "firstName lastName");
            string expectedResult = "name (03:30) will be performed by firstName lastName";
            Assert.That(stage.AddSongToPerformer("name", "firstName lastName"), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PlayMethodReturnsExpectedResult()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSong(new Song("invalid", new TimeSpan(0, 3, 0)));
            stage.AddSongToPerformer("name", "firstName lastName");
            string expectedResult = "1 performers played 1 songs";
            Assert.That(stage.Play(), Is.EqualTo(expectedResult));
        }
    }
}