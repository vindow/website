'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('map', {
		id: {
			type: type.INTEGER,
			primaryKey: true,
			autoIncrement: true
		},
		name: type.STRING(32),
		type: {
			type: type.SMALLINT,
			defaultValue: 0,
		},
		statusFlag: {
			type: type.SMALLINT,
			defaultValue: 2
		},
		downloadURL: type.STRING,
		hash: type.CHAR(40),
	})
};
