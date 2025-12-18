import express, {} from "express";
const app = express();
const PORT = 3000;
app.get("/items", (req, res) => {
    res.send(["item1", "item2", "item3"]);
});
app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
});
//# sourceMappingURL=index.js.map