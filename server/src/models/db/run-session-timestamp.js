'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('runSessionTimestamp', {
		id: {
			type: type.BIGINT,
			primaryKey: true,
			autoIncrement: true
		},
		zone: type.SMALLINT,
		tick: type.INTEGER,
	})
};
