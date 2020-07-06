'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('run', {
		id: {
			type: type.BIGINT,
			primaryKey: true,
			autoIncrement: true
		},
		trackNum: type.SMALLINT,
		zoneNum: type.SMALLINT,
		ticks: type.INTEGER,
		tickRate: type.FLOAT,
		time: {
			type: type.VIRTUAL,
			get() {
				return this.getDataValue('ticks') * this.getDataValue('tickRate');
			}
		},
		flags: type.INTEGER,
		file: type.STRING,
		hash: type.STRING(40),
	}, {
		indexes: [
			{
				fields: ['flags'],
			}
		]
	});
};
