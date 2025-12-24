import axios from "axios";

class AuditLogsClient {
  constructor() {}

  addAuditLog(event_type: string, payload: any) {
    console.log(process.env.AUDIT_LOGS_SERVICE_URL);
    return axios.post(process.env.AUDIT_LOGS_SERVICE_URL as string, {
      event_type,
      payload,
    });
  }
}

const auditLogClient = new AuditLogsClient();

export {auditLogClient};
