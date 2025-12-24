import "dotenv/config";
import express, {type Request, type Response} from "express";
import {itemsRepository} from "./itemsRepository.js";
import {auditLogClient} from "./auditLogsClient.js";

const app = express();
app.use(express.json());

const PORT = 3000;

app.get("/", (req: Request, res: Response) => {
  res.status(200).send({});
});

app.get("/api/items", async (req: Request, res: Response) => {
  res.send(await itemsRepository.getItems());
});

app.post("/api/items", async (req: Request, res: Response) => {
  const item = await itemsRepository.addItem({
    title: req.body.title,
    body: req.body.body,
  });
  await auditLogClient.addAuditLog("item.created", item);
  res.send(item);
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
