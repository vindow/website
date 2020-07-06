'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('userStats', {
		totalJumps: {
			type: type.BIGINT,
			defaultValue: 0,
		},
		totalStrafes: {
			type: type.BIGINT,
			defaultValue: 0,
		},
		level: {
			type: type.SMALLINT,
			defaultValue: 1,
		},
		cosXP: {
			type: type.BIGINT,
			defaultValue: 0,
		},
		mapsCompleted: {
			type: type.INTEGER,
			defaultValue: 0,
		},
		runsSubmitted: {
			type: type.INTEGER,
			defaultValue: 0,
		}
	})
};
