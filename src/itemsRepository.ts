import {Pool} from "pg";
import type {Item} from "./item.js";

class ItemsRepository {
  private pool: Pool;

  constructor() {
    this.pool = new Pool({
      user: process.env.POSTGRES_USER,
      host: process.env.POSTGRES_HOST,
      database: process.env.POSTGRES_DB,
      password: process.env.POSTGRES_PASSWORD,
      port: parseInt(process.env.POSTGRES_PORT || "5432", 10),
    });
  }

  async getItems() {
    const result = await this.pool.query<Item>("select * from items");
    return result.rows;
  }

  async addItem(item: Omit<Item, "id" | "created_at" | "updated_at">) {
    const result = await this.pool.query<Item>(
      "INSERT INTO items(title, body) VALUES($1, $2) RETURNING *",
      [item.title, item.body]
    );

    return result.rows[0];
  }
}

const itemsRepository = new ItemsRepository();

export {itemsRepository};
