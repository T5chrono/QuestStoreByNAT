﻿using System;
using QuestStoreNAT.web.Models;
using Npgsql;

namespace QuestStoreNAT.web.DatabaseLayer
{
    public class StudentAcceptanceDAO : DBAbstractRecord<StudentAcceptance>
    {
        public override string DBTableName { get; set; } = "StudentAcceptance";
        private enum StudentAcceptanceEnum
        {
            Id, studentID, artifactID, artifactName, amountOfAcceptance, acceptance
        }

        public override StudentAcceptance ProvideOneRecord(NpgsqlDataReader reader)
        {
            var studentAcceptance = new StudentAcceptance();
            studentAcceptance.ID = reader.GetInt32((int)StudentAcceptanceEnum.Id);
            studentAcceptance.studentID = reader.GetInt32((int)StudentAcceptanceEnum.studentID);
            studentAcceptance.artifactID = reader.GetInt32((int)StudentAcceptanceEnum.artifactID);
            studentAcceptance.artifactName = reader.GetString((int)StudentAcceptanceEnum.artifactName);
            studentAcceptance.amountOfAcceptance = reader.GetInt32((int)StudentAcceptanceEnum.amountOfAcceptance);
            studentAcceptance.acceptance = reader.GetBoolean((int)StudentAcceptanceEnum.acceptance);
            return studentAcceptance;
        }

        public override string ProvideQueryStringToAdd(StudentAcceptance studentAcceptanceToAdd)
        {
            var query = $"INSERT INTO \"NATQuest\".\"{DBTableName}\" (\"StudentID\", \"ArtifactID\", \"Acceptance\")" +
                        $"VALUES({(int)studentAcceptanceToAdd.studentID}, " +
                               $"'{studentAcceptanceToAdd.artifactID}', " +
                               $"'{studentAcceptanceToAdd.acceptance}');";
            return query;
        }

        public override string ProvideQueryStringToUpdate(StudentAcceptance studentAcceptanceToUpdate)
        {
            var query = $"UPDATE \"NATQuest\".\"{DBTableName}\" " +
                        $"SET \"StudentID\" = {(int)studentAcceptanceToUpdate.studentID}, " +
                            $"\"ArtifactID\" = '{studentAcceptanceToUpdate.artifactID}', " +
                            $"\"Acceptance\" = '{studentAcceptanceToUpdate.acceptance}', " +
                        $"WHERE \"NATQuest\".\"{DBTableName}\".\"ID\" = {studentAcceptanceToUpdate.ID};";
            return query;
        }

        public override StudentAcceptance FindOneRecordBy(int id)
        {
            using NpgsqlConnection connection = OpenConnectionToDB();
            var query = $"SELECT * FROM \"NATQuest\".\"{DBTableName}\" WHERE \"NATQuest\".\"{DBTableName}\".\"StudentID\" = '{id}' LIMIT 1;";
            using var command = new NpgsqlCommand(query, connection);
            var reader = command.ExecuteReader();

            var oneRecord = default(StudentAcceptance);
            while (reader.Read())
            {
                oneRecord = ProvideOneRecord(reader);
            };
            return oneRecord;
        }

    }
}
