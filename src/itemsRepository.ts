const {Pool} = require("pg");

export class ItemsRepository {
  private pool: any;

  constructor() {
    this.pool = new Pool({
      user: "myuser",
      host: "postgres-release-postgresql",
      database: "mydatabase",
      password: "cN7g6N1yhe%",
      port: 5432,
    });
  }
}
