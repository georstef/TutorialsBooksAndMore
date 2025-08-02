### 📌 **Issue: Missing Columns When Using `SELECT *` with `ROW_NUMBER()` on Temp Tables in SQL Server**

#### 🔍 **Problem**

When running a query like:

```sql
SELECT #MyTempTable.*, ROW_NUMBER() OVER (ORDER BY SomeID) AS RowNum
FROM #MyTempTable
ORDER BY SomeOtherID;
```

…you may notice that **some columns are unexpectedly missing** from the result — even though they exist in the underlying temp table (`#MyTempTable`). 
This typically occurs when the table has a **large number of columns**, or when it is **created/populated dynamically** (e.g., via dynamic SQL or PIVOT operations).

---

#### ⚙️ **Cause**

SQL Server caches **query execution plans** for performance.
When using `SELECT *` on a temporary table together with **window functions** like `ROW_NUMBER()`, SQL Server may cache **incomplete column metadata**. 
This leads to some columns being **excluded** from the result set, especially if:

* The temp table was created using dynamic SQL (`EXEC sp_executesql`) or `SELECT INTO`
* The set of columns changed between executions
* The window function forces a metadata evaluation during compilation

This is a **metadata caching issue**, not a UI or schema problem.

---

#### ✅ **Solution**

Add the `OPTION (RECOMPILE)` hint to your query:

```sql
SELECT #MyTempTable.*, ROW_NUMBER() OVER (ORDER BY SomeID) AS RowNum
FROM #MyTempTable
ORDER BY SomeOtherID
OPTION (RECOMPILE);
```

This forces SQL Server to:

* **Recompile** the execution plan
* **Refresh** column metadata from the temp table
* Return the **complete and correct** result set

---

#### 🧼 **Best Practices**

* Avoid `SELECT *` when querying complex or dynamic temp tables — list needed columns explicitly.
* Use `OPTION (RECOMPILE)` in scenarios where dynamic schema or wide tables are involved.
* Always validate column presence when using dynamic pivots or variable columns.

---

This happened in the Ημερολόγιο Ωραρίου/Βαρδιών.
In the dmPayMFLHmerologioSearch.qryPayMFLHmerologioPivot query.

```sql
select
  #payMFLHmerologioPivot.*,
  row_number() OVER (ORDER BY payMFLHmerologioPivotID) AS AA
from
  #payMFLHmerologioPivot
order by
  payMFLID
OPTION (RECOMPILE);
```
