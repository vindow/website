'use strict';

const { Map, User, Run } = require('../../../config/sqlize');

module.exports = (sequelize, type) => {
	return sequelize.define('mapRank', {
		mapID: {
			type: type.INTEGER,
			primaryKey: true,
			foreignKey: true,
			references: {
				model: Map,
				key: 'id',
			}
		},
		userID: {
			type: type.INTEGER,
			primaryKey: true,
			foreignKey: true,
			references: {
				model: User,
				key: 'id',
			}
		},
		gameType: {
			type: type.SMALLINT,
			primaryKey: true,
		},
		flags: {
			type: type.INTEGER,
			primaryKey: true,
			defaultValue: 0,
		},
		trackNum: {
			type: type.SMALLINT,
			primaryKey: true,
			defaultValue: 0,
		},
		zoneNum: {
			type: type.SMALLINT,
			primaryKey: true,
			defaultValue: 0,
		},
		runID: {
			type: type.BIGINT,
			foreignKey: true,
			references: {
				model: Run,
				key: 'id',
			}
		},
		rank: type.INTEGER,
		rankXP: {
			type: type.INTEGER,
			defaultValue: 0,
		},
	});
};